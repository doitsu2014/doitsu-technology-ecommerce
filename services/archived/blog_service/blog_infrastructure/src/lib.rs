pub mod schema;
pub mod data_access_services;

use diesel::{pg::Pg, Connection, PgConnection, migration::MigrationVersion};
use diesel_migrations::{embed_migrations, EmbeddedMigrations, MigrationHarness};
use std::error::Error;

const MIGRATIONS: EmbeddedMigrations = embed_migrations!("migrations");

pub fn initialize_db(connection_string: String) {
    let mut conn = PgConnection::establish(&connection_string)
        .unwrap_or_else(|error| panic!("Error connecting to {}: {}", connection_string, error));
    run_migrations(&mut conn)
        .unwrap_or_else(|_| panic!("Error migrating database {}", connection_string));
}

fn run_migrations(
    connection: &mut impl MigrationHarness<Pg>,
) -> Result<Vec<MigrationVersion>, Box<dyn Error + Send + Sync + 'static>> {
    connection.run_pending_migrations(MIGRATIONS)
}