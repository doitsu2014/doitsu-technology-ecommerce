use std::error::Error;

use crate::entities::blog::Blog;

pub trait BlogDas {
    fn get_blog(&self, id: i32) -> Result<Blog, Box<dyn Error>>;
    fn get_blogs(&self) -> Result<Vec<Blog>, Box<dyn Error>>;
    fn create_blog(&self, blog: &Blog) -> Result<Blog, Box<dyn Error>>;
    fn update_blog(&self, blog: &Blog) -> Result<Blog, Box<dyn Error>>;
    fn delete_blog(&self, id: i32) -> Result<(), Box<dyn Error>>;
}
