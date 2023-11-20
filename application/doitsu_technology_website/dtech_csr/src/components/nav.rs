use yew::{function_component, html, Html};
use yew_router::Router;

#[function_component]
pub fn Nav() -> Html {
    html! {
    <nav class="bg-black w-full block">
        <div class="h-24 text-white">
            <p>{"Good Time To See You"}</p>
        </div>
    </nav>
    }
}
