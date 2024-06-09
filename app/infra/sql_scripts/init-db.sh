#!/bin/bash
set -e

# Conecte-se ao banco de dados postgres e execute o comando
psql -v ON_ERROR_STOP=1 --username "$POSTGRES_USER" --dbname "postgres" <<-EOSQL
  CREATE EXTENSION IF NOT EXISTS dblink;
  DO \$\$
  BEGIN
      IF NOT EXISTS (SELECT FROM pg_database WHERE datname = 'XP_INC') THEN
          PERFORM dblink_exec('CREATE DATABASE "XP_INC"');
      END IF;
  END
  \$\$;
EOSQL
