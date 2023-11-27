use yew::{ function_component, Html, html };
use yew::prelude::*;
use yew_router::history::{ AnyHistory, History, MemoryHistory };
use yew_router::prelude::*;

use crate::common::initialize_scripts;
use crate::components::nav::Nav;
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
    // #[at("/posts")]
    // Posts,
}

#[function_component]
pub fn App() -> Html {
    use_effect(move || { 
        initialize_scripts() 
    
    });

    html! {
        <BrowserRouter>
            <Nav>
            </Nav>
            <main>
                <Switch<Route> render={switch} />
            </main>

            <footer class="footer">
                <div class="content has-text-centered">
                    { "Powered by " }
                    <a href="https://yew.rs">{ "Yew" }</a>
                    { " using " }
                    <a href="https://bulma.io">{ "Bulma" }</a>
                    { " and images from " }
                    <a href="https://unsplash.com">{ "Unsplash" }</a>
                </div>
            </footer>
        </BrowserRouter>
    }
}

fn switch(routes: Route) -> Html {
    match routes {
        // Route::Post { id } => {
        //     html! { <Post seed={id} /> }
        // }
        // Route::Posts => {
        //     html! { <PostList /> }
        // }
        Route::Home => {
            html! { <PageHome /> }
        }
        Route::NotFound => {
            html! { <PageNotFound /> }
        }
    }
}
