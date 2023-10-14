use serde::{Deserialize, Serialize};

#[derive(Debug, Serialize, Deserialize)]
pub struct Tag {
    pub id: uuid::Uuid,
    pub name: String,
    pub slug: String,
}
