use diesel::{table, joinable, allow_tables_to_appear_in_same_query};

use crate::schema::post::posts;

table! {
    blogs (id) {
        id -> Uuid,
        name -> Text,
        description -> Text,
        slug -> Text,
    }
}


joinable!(posts -> blogs (blog_id));
allow_tables_to_appear_in_same_query!(blogs, posts);