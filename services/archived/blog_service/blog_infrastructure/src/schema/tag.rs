use diesel::{allow_tables_to_appear_in_same_query, joinable, table};

use crate::schema::post::posts;

table! {
    tags (id) {
        id -> Uuid,
        name -> Text,
        slug -> Text,
    }
}

table! {
    posts_tags (post_id, tag_id) {
        post_id -> Uuid,
        tag_id -> Uuid,
    }
}

// ... existing definitions for blogs and posts ...

joinable!(posts_tags -> posts (post_id));
joinable!(posts_tags -> tags (tag_id));
allow_tables_to_appear_in_same_query!(posts, tags, posts_tags);
