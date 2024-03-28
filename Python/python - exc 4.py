import random
import matplotlib.pyplot as plt 

class Variable:
    def __init__(self, name, domain, position=None):
        self.name = name
        self.domain = domain
        self.position = position

class Constraint:
    def __init__(self, scope, condition, string=None, position=None):
        self.scope = scope
        self.condition = condition
        if string is None:
            self.string = self.condition.__name__ + str(self.scope)
        else:
            self.string = string
        self.position = position

    def __repr__(self):
        return self.string

class CSP:
    def __init__(self, title, variables, constraints):
        self.title = title
        self.variables = variables
        self.constraints = constraints
        self.var_to_const = {var: set() for var in self.variables}
        for con in constraints:
            for var in con.scope:
                self.var_to_const[var].add(con)

    def __str__(self):
        return str(self.title)

    def __repr__(self):
        return f"CSP({self.title}, {self.variables}, {[str(c) for c in self.constraints]})"

    def show(self):
        plt.ion()  # interactive
        ax = plt.figure().gca()
        ax.set_axis_off()
        plt.title(self.title)
        var_bbox = dict(boxstyle="round4,pad=1.0,rounding_size=0.5")
        con_bbox = dict(boxstyle="square,pad=1.0", color="green")

        for var in self.variables:
            if var.position is None:
                var.position = (random.random(), random.random())

        for con in self.constraints:
            if con.position is None:
                con.position = tuple(sum(var.position[i] for var in con.scope) / len(con.scope) for i in range(2))

            for var in con.scope:
                ax.annotate(con.string, var.position, xytext=con.position,
                            arrowprops={'arrowstyle': '-'}, bbox=con_bbox,
                            ha='center')

        for var in self.variables:
            x, y = var.position
            plt.text(x, y, var.name, bbox=var_bbox, ha='center')

def meet_at(p1, p2):
    def meets(w1, w2):
        return w1[p1] == w2[p2]
    meets.__name__ = "meet_at(" + str(p1) + ', ' + str(p2) + ')'
    return meets

# Variable instances
one_across = Variable('one_across', {'ant', 'big', 'bus', 'car', 'has'},
                      position=(0.3, 0.9))
one_down = Variable('one_down', {'book', 'buys', 'hold', 'lane', 'year'},
                    position=(0.1, 0.7))
two_down = Variable('two_down', {'ginger', 'search', 'symbol', 'syntax'},
                    position=(0.9, 0.8))
three_across = Variable('three_across', {'book', 'buys', 'hold', 'land', 'year'},
                        position=(0.1, 0.3))
four_across = Variable('four_across', {'ant', 'big', 'bus', 'car', 'has'},
                       position=(0.7, 0.0))

# Constraint instances
crossword = CSP("crossword1", {one_across, one_down, two_down, three_across, four_across},
                [Constraint([one_across, one_down], meet_at(0, 0)),
                 Constraint([one_across, two_down], meet_at(2, 0)),
                 Constraint([three_across, two_down], meet_at(2, 2)),
                 Constraint([three_across, one_down], meet_at(0, 2)),
                 Constraint([four_across, two_down], meet_at(0, 4))])
