use yew::{ function_component, Html, html };
use yew_router::{ Router };

#[function_component]
pub fn PageHome() -> Html {
    html! {
        <section class="flex text-center text-xl">
            {"Home Page"}
        </section>
    }
}
