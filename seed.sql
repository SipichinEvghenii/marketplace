CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

DO $$
    DECLARE
        AdminRoleId UUID := uuid_generate_v4();
        UserRoleId UUID := uuid_generate_v4();
        AdminUserId UUID := uuid_generate_v4();
    BEGIN
        -- Вставка ролей
        INSERT INTO dbo."Roles" ("RoleId", "Name") VALUES (AdminRoleId, 'Admin');
        INSERT INTO dbo."Roles" ("RoleId", "Name") VALUES (UserRoleId, 'User');

        -- Вставка пользователя
        INSERT INTO dbo."Users" ("UserId", "Username", "Email", "PasswordSalt", "PasswordHash", "RoleId")
        VALUES (AdminUserId, 'admin', 'admin@example.com', NULL, 'hash', AdminRoleId);

        -- Вставка заказов
        INSERT INTO dbo."Orders" ("OrderId", "OrderDate", "TotalPrice", "Status", "UserId")
        VALUES (uuid_generate_v4(), now(), 100.00, 'Pending', AdminUserId);

        INSERT INTO dbo."Orders" ("OrderId", "OrderDate", "TotalPrice", "Status", "UserId")
        VALUES (uuid_generate_v4(), now(), 200.00, 'Delivered', AdminUserId);
    END $$;