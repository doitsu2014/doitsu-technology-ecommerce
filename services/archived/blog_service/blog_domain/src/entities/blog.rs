use serde::{Deserialize, Serialize};

#[derive(Debug, Serialize, Deserialize)]
pub struct Blog {
    pub id: uuid::Uuid,
    pub name: String,
    pub description: String,
    pub slug: String,
}
