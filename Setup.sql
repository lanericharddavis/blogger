/* CREATE TABLE profiles (
id INT NOT NULL AUTO_INCREMENT,
name VARCHAR(255) NOT NULL,
email VARCHAR(255),
picture VARCHAR(255),

PRIMARY KEY(id)
); */

CREATE TABLE blogs (
id INT NOT NULL AUTO_INCREMENT,
title VARCHAR(255),
body VARCHAR(255),
imgUrl VARCHAR(255),
published TINYINT DEFAULT 0,
creatorId VARCHAR(255),
PRIMARY KEY(id),
FOREIGN KEY(profilesId)
REFERENCES profiles(id)
);

/* INSERT INTO profiles
(id, name, email, picture)
VALUES
(1, Voldemort) */