package com.example.demo.mapper;

import com.example.demo.dto.UserDto;
import com.example.demo.entity.User;

public class UserMapper {

    public static UserDto mapToUserDto(User user) {
        return new UserDto(
                user.getId(),
                user.getName(),
                user.getDateOfBirth(),
                user.getAge(),
                user.getEmail(),
                user.getAddress()
        );
    }

    public static User mapToUser(UserDto userDto) {
        User user = new User(
                userDto.getId(),
                userDto.getName(),
                userDto.getDateOfBirth(),
                userDto.getEmail(),
                userDto.getAddress()
        );
        return user;
    }
}
