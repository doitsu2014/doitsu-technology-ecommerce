use yew::{ function_component, Html, html };


#[function_component]
pub fn PageNotFound() -> Html {
    html! {
        <section class="flex text-center text-xl">
            {"You page was not found. Please try another."}
        </section>
    }
}
