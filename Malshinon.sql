/*
  Name: MySQL Sample Database classicmodels
  Link: http://www.mysqltutorial.org/mysql-sample-database.aspx
*/



/* Create the database */
CREATE DATABASE  IF NOT EXISTS Malshinon;

/* Switch to the classicmodels database */
USE Malshinon;

/* Drop existing tables  */
/*DROP TABLE IF EXISTS people; */




/* Create the tables */
CREATE TABLE IF NOT EXISTS people (
  id INT AUTO_INCREMENT PRIMARY KEY,
  first_name varchar(50) unique,
  last_name  varchar(50) DEFAULT NULL,
  secret_code varchar(50) UNIQUE,
  type_poeple ENUM('reporter', 'target', 'both', 'potential_agent') DEFAULT 'reporter',
  num_reports INT DEFAULT 0,
  num_mentions  INT DEFAULT 0
  
);


CREATE TABLE IF NOT EXISTS IntelReports  (
  id INT AUTO_INCREMENT PRIMARY KEY,
  reporter_id INT,
  target_id INT,
  `text` TEXT,
 `timestamp` DATETIME DEFAULT NOW(),

  FOREIGN KEY (reporter_id) REFERENCES people (id),
  FOREIGN KEY (target_id) REFERENCES people (id)
);