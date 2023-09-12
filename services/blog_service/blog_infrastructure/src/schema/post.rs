use diesel::table;

table! {
    posts (id) {
        id -> Uuid,
        blog_id -> Uuid,
        title -> Text,
        body -> Text,
        slug -> Text,
    }
}