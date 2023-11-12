use yew::{function_component, Html, html};
use yew::prelude::*;
use yew_router::prelude::*;

#[function_component]
pub fn App() -> Html {
    html! {
        <section class="w-full flex">
            <article class="flex-1 text-center prose lg:prose-xl">
                { "# First Blog" }
            </article>
        </section>
        // <BrowserRouter>
        //     <Nav />
        //     <main>
        //         <Switch<Route> render={switch} />
        //     </main>
        //     <footer class="footer">
        //         <div class="content has-text-centered">
        //             { "Powered by " }
        //             <a href="https://yew.rs">{ "Yew" }</a>
        //             { " using " }
        //             <a href="https://bulma.io">{ "Bulma" }</a>
        //             { " and images from " }
        //             <a href="https://unsplash.com">{ "Unsplash" }</a>
        //         </div>
        //     </footer>
        // </BrowserRouter>
    }
}
