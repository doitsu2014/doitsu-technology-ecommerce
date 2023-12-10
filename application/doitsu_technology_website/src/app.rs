use std::collections::HashMap;

use gloo::history::{AnyHistory, History, MemoryHistory};
use yew::prelude::*;
use yew::{function_component, html, Html};
use yew_router::prelude::*;

use crate::common::initialize_scripts;
use crate::components::navigation::nav_bar::NavBar;
use crate::pages::home::PageHome;
use crate::pages::not_found::PageNotFound;
use crate::pages::posts::PagePosts;

#[derive(Routable, PartialEq, Eq, Clone, Debug)]
pub enum Route {
    #[at("/")]
    Home,
    #[not_found]
    #[at("/not-found")]
    NotFound,
    #[at("/post/:id")]
    Post { id: u32 },
    #[at("/posts")]
    Posts,
}

#[function_component]
pub fn App() -> Html {
    use_effect(move || initialize_scripts());

    html! {
        <BrowserRouter>
            <NavBar />

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

#[derive(Properties, PartialEq, Eq, Debug)]
pub struct ServerAppProps {
    pub url: AttrValue,
    pub queries: HashMap<String, String>,
}

#[function_component]
pub fn ServerApp(props: &ServerAppProps) -> Html {
    let history = AnyHistory::from(MemoryHistory::new());
    history
        .push_with_query(&*props.url, &props.queries)
        .unwrap();

    html! {
        <Router history={history}>
            <NavBar />

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
        </Router>
    }
}

fn switch(routes: Route) -> Html {
    match routes {
        Route::Home => {
            html! { <PageHome /> }
        }
        Route::NotFound => {
            html! { <PageNotFound /> }
        }
        Route::Posts => {
            html! { <PagePosts /> }
        }
        Route::Post { id: _u32 } => {
            todo!()
        }
    }
}
