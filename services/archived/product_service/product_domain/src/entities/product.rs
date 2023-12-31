use chrono::{DateTime, Utc};
use serde::{Deserialize, Serialize};
use uuid::Uuid;

#[derive(Debug, Serialize, Deserialize)]
pub struct Product {
    pub id: Uuid,
    pub name: String,
    pub description: String,
    pub price: f64,
    pub created_at: DateTime<Utc>,
    pub updated_at: DateTime<Utc>,
}

#[derive(Debug, Serialize, Deserialize)]
pub struct ProductAttributes {
    pub attribute_code: String,
    pub product_id: String,
}

#[derive(Debug, Serialize, Deserialize)]
pub struct Attributes {
    pub code: String,
    pub display_name: String,
    pub value: String,
}

#[derive(Debug, Serialize, Deserialize)]
pub struct AttributeTypes {
    pub code: String,
    pub display_name: String,
}
