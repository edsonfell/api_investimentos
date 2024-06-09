CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE produtos_financeiros (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    nome VARCHAR(100),
    descricao TEXT,
    valor_cota NUMERIC,
    vencimento DATE
);

CREATE TABLE usuarios (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    nome VARCHAR(100),
    email VARCHAR(100),
    cpf VARCHAR(11) UNIQUE
);

CREATE TABLE controle_investimentos (
    id UUID PRIMARY KEY DEFAULT uuid_generate_v4(),
    id_usuario UUID REFERENCES usuarios(id),
    id_produtos_financeiros UUID REFERENCES produtos_financeiros(id),
    quantidade_cotas NUMERIC
);


INSERT INTO produtos_financeiros (nome, descricao, valor_cota, vencimento)
VALUES 
    ('CDB XPTO', 'Descrição do CDP XPTO', 100, '2024-06-10'),
    ('Tesouro Direto XPTO', 'Descrição do Tesouro Direto XPTO', 500, '2024-06-15'),
    ('Fundo de Investimento XPTO', 'Descrição do Fundo de Investimento XPTO', 250, '2024-06-20');

INSERT INTO usuarios (nome, email, cpf)
VALUES 
    ( 'João Silva', 'joao.silva@jmail.com.br', 12345678912),
    ( 'Pedro Antunes', 'pedro_antunes@coldmail.com.br', 57937236493),
    ( 'Maria Antonia', 'maria.antonia@inlook.com.br', 98765432101);
