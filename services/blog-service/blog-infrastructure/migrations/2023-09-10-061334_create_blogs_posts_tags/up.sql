CREATE TABLE blogs (
    id UUID PRIMARY KEY,
    name TEXT NOT NULL,
    description TEXT,
    slug TEXT NOT NULL,
    UNIQUE(slug)
);

CREATE INDEX idx_blogs_name ON blogs(name);

CREATE TABLE posts (
    id UUID PRIMARY KEY,
    blog_id UUID REFERENCES blogs(id),
    title TEXT NOT NULL,
    body TEXT,
    slug TEXT NOT NULL,
    UNIQUE(slug)
);

CREATE INDEX idx_posts_title ON posts(title);
CREATE INDEX idx_posts_blog_id ON posts(blog_id);

CREATE TABLE tags (
    id UUID PRIMARY KEY,
    name TEXT NOT NULL,
    slug TEXT NOT NULL,
    UNIQUE(slug)
);

CREATE INDEX idx_tags_name ON tags(name);

CREATE TABLE posts_tags (
    post_id UUID REFERENCES posts(id),
    tag_id UUID REFERENCES tags(id),
    PRIMARY KEY (post_id, tag_id)
);

CREATE INDEX idx_posts_tags_post_id ON posts_tags(post_id);
CREATE INDEX idx_posts_tags_tag_id ON posts_tags(tag_id);
