use serde::{Deserialize, Serialize};

// models.rs
#[derive(Debug, Serialize, Deserialize)]
pub struct Post {
    pub id: uuid::Uuid,
    pub blog_id: uuid::Uuid,
    pub title: String,
    pub body: String,
    pub slug: String,
}
