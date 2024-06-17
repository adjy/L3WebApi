CREATE TABLE games (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    description TEXT NOT NULL,
    logo VARCHAR(255) NOT NULL
);

INSERT INTO games (id, name, description, logo) VALUES
(1, 'Zelda', 'Zelda le fameux jeu', 'logo Zelda');
