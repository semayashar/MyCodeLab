using HtmlAgilityPack;
using System.Globalization;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;

namespace ParseProductsFromHTML
{
    // Represents a product with consistent naming
    public record Product(
        [property: JsonPropertyName("productName")] string ProductName,
        [property: JsonPropertyName("productPrice")] string ProductPrice,
        [property: JsonPropertyName("productRating")] string ProductRating
    );

    internal class Program
    {
        private static void Main(string[] args)
        {
            string htmlPath = "products.html";

            try
            {
                if (!File.Exists(htmlPath))
                {
                    Console.WriteLine($"ERROR: File not found: {htmlPath}");
                    return;
                }

                string htmlCode = File.ReadAllText(htmlPath);

                if (string.IsNullOrWhiteSpace(htmlCode))
                {
                    Console.WriteLine("ERROR: HTML file is empty.");
                    return;
                }

                HtmlDocument htmlDocument = new();
                htmlDocument.LoadHtml(htmlCode);

                HtmlNodeCollection productNodes = htmlDocument.DocumentNode.SelectNodes("//div[@class='item']");

                if (productNodes == null || productNodes.Count == 0)
                {
                    Console.WriteLine("WARNING: No <div> elements with class 'item' found.");
                    return;
                }

                List<Product> parsedProducts = new();

                foreach (HtmlNode productNode in productNodes)
                {
                    try
                    {
                        string productName = ExtractProductName(productNode);
                        string productPrice = ExtractProductPrice(productNode);
                        string productRating = ExtractProductRating(productNode);

                        Product product = new(productName, productPrice, productRating);
                        parsedProducts.Add(product);
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine($"Skipped one item (parse error): {ex.Message}");
                    }
                }

                if (parsedProducts.Count == 0)
                {
                    Console.Error.WriteLine("No valid products parsed.");
                    return;
                }

                // Serialize results to formatted JSON
                string jsonOutput = JsonSerializer.Serialize(
                    parsedProducts,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true,
                        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                    }
                );

                Console.WriteLine(jsonOutput);
            }

            catch (FileNotFoundException)
            {
                Console.Error.WriteLine($"Could not find file '{htmlPath}'.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.Error.WriteLine($"No permission to read file '{htmlPath}'.");
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"I/O error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        // Parses a string and returns a decimal after cleaning up symbols and formatting
        private static decimal ParseDecimalValue(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            string cleaned = input.Replace("$", "").Replace(" ", "").Trim();

            // Handle locale-based comma/decimal issues
            if (cleaned.Contains(",") && !cleaned.Contains("."))
                cleaned = cleaned.Replace(",", ".");
            else
                cleaned = cleaned.Replace(",", "");

            if (decimal.TryParse(cleaned, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            return 0;
        }

        // Extracts the product name from either image alt text or a title link
        private static string ExtractProductName(HtmlNode productNode)
        {
            HtmlNode imageNode = productNode.SelectSingleNode(".//figure//img[@alt]");
            if (imageNode != null)
            {
                string productName = WebUtility.HtmlDecode(imageNode.GetAttributeValue("alt", "").Trim());
                if (!string.IsNullOrEmpty(productName))
                    return productName;
            }

            HtmlNode titleNode = productNode.SelectSingleNode(".//h4/a");
            if (titleNode != null)
            {
                string rawTitle = titleNode.InnerText;
                if (!string.IsNullOrEmpty(rawTitle))
                    return WebUtility.HtmlDecode(rawTitle.Trim());
            }

            return string.Empty;
        }

        // Extracts the product price text and converts it to a standardized format
        private static string ExtractProductPrice(HtmlNode productNode)
        {
            HtmlNode priceNode = productNode.SelectSingleNode(".//span[contains(@class,'price-display')]/span[@style='display: none']");
            string priceText = priceNode?.InnerText.Trim() ?? string.Empty;

            decimal priceValue = ParseDecimalValue(priceText);
            return priceValue.ToString("0.00", CultureInfo.InvariantCulture);
        }

        // Extracts and normalizes the product rating to a 0–5 scale
        private static string ExtractProductRating(HtmlNode productNode)
        {
            string ratingText = productNode.GetAttributeValue("rating", "").Trim();
            decimal ratingValue = ParseDecimalValue(ratingText);

            if (ratingValue > 5)
            {
                if (ratingValue <= 10)
                    ratingValue /= 2.0m;
                else
                    ratingValue = 5;
            }

            return ratingValue.ToString("0.#", CultureInfo.InvariantCulture);
        }
    }
}
