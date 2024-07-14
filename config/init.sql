CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

ALTER DATABASE CHARACTER SET utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240712220034_InitialCreate', '8.0.7');

COMMIT;

START TRANSACTION;

CREATE TABLE `Goals` (
    `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
    `Text` longtext CHARACTER SET utf8mb4 NOT NULL,
    `IsChecked` tinyint(1) NOT NULL,
    CONSTRAINT `PK_Goals` PRIMARY KEY (`Id`)
) CHARACTER SET=utf8mb4;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20240712220206_DailyGoal', '8.0.7');

COMMIT;

