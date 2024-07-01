package com.example.demo.services;

import com.example.demo.dto.UserDto;

import java.util.List;

public interface UserService {
    UserDto createUser(UserDto userDto);

    UserDto getUserByID(Long userID);

    List<UserDto> getAllUsers();

    UserDto updateUser(Long userID, UserDto userDto);

    void deleteUser(Long userID);  // New method

    void deleteAllUsers();  // New method
}
