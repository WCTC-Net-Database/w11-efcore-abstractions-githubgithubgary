SET IDENTITY_INSERT Item ON;
INSERT INTO Item (Id, [Description], ItemType, HitPoints, Protection, Damage)
VALUES
    (0, 'Unarmed', 'Weapon', 0, 0, 0),
    (1, 'Unarmored', 'Armor', 0, 0, 0),
    (2, 'Short Sword', 'Weapon', 50, 1, 5),
    (3, 'Broad Sword', 'Weapon', 75, 2, 10),
    (4, 'Chainmail', 'Armor', 10, 10, 0),
    (5, 'Leather', 'Armor', 25, 1, 0);
SET IDENTITY_INSERT Item OFF;

SET IDENTITY_INSERT Equipment ON;
INSERT INTO Equipment (Id, PlayerID, WeaponID, ArmorID, ArmorHealth, WeaponHealth)
VALUES
    (1, 1, 2, 5, 50, 25)
SET IDENTITY_INSERT Equipment OFF;
