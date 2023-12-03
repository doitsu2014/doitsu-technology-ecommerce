use yew::{ function_component, Html, html };
use yew::prelude::*;
use yew_router::prelude::*;

use crate::common::initialize_scripts;
use crate::components::navigation::nav_bar::NavBar;
use crate::pages::blogs::PageBlogs;
use crate::pages::home::PageHome;
use crate::pages::not_found::PageNotFound;

#[derive(Routable, PartialEq, Eq, Clone, Debug)]
pub enum Route {
    #[at("/")]
    Home,
    #[not_found]
    #[at("/not-found")]
    NotFound,
    // #[at("/posts/:id")]
    // Post { id: u32 },
    #[at("/blogs")]
    Blogs,
}

#[function_component]
pub fn App() -> Html {
    use_effect(move || { 
        initialize_scripts() 
    
    });

    html! {
        <BrowserRouter>
            <NavBar>
            </NavBar>

            <main>
                <Switch<Route> render={switch} />
            </main>

            <footer class="flex w-full mt-4">
                <div class="mx-auto text-center">
                    { "Powered by " } <br/>
                    <a href="https://yew.rs">{ "Doitsu Technology" }</a> <br/>
                    { "using " } <br/>
                    <a href="https://yew.rs">{ "Rust yew" }</a>
                </div>
            </footer>
        </BrowserRouter>
    }
}

fn switch(routes: Route) -> Html {
    match routes {
        Route::Home => {
            html! { <PageHome /> }
        },
        Route::NotFound => {
            html! { <PageNotFound /> }
        },
        Route::Blogs => {
            html! { <PageBlogs /> }
        }
    }
}
