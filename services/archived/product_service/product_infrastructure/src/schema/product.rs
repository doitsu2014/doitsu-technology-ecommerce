use diesel::{
    prelude::{Insertable, Queryable},
    result::DatabaseErrorInformation, table,
};
use uuid::Uuid;

table! {
    products (id) {
        id -> Uuid,
        name -> Text
    }
}

// src/models.rs in product-infrastructure
#[derive(Queryable, Insertable)]
#[diesel(table_name = products)]
pub struct ProductSchema {
    pub id: Uuid,
    pub name: String,
}