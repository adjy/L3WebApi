CREATE DATABASE l3webapi
    WITH
    OWNER = l3webapi
    ENCODING = 'UTF8'
    LOCALE_PROVIDER = 'libc'
    CONNECTION LIMIT = -1
    IS_TEMPLATE = False;

INSERT INTO games (name, description, logo) VALUES
('Zelda', 'Zelda le fameux jeu', 'logo Zelda');
