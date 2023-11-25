use yew::{ function_component, Html, html };
use yew_router::{ Router };

#[function_component]
pub fn PageNotFound() -> Html {
    html! {
        <section class="flex text-center text-xl">
            {"You page was not found. Please try another."}
        </section>
    }
}
