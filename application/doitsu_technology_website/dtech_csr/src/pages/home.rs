use yew::{ function_component, Html, html };
use yew_router::{ Router };

use crate::components::skeletons::image_placeholder_skeleton::ImagePlaceholderSkeleton;

#[function_component]
pub fn PageHome() -> Html {
    let items = (1..=80).collect::<Vec<_>>();

    html! {
        <section class="flex flex-col text-center text-xl mt-4">
            <span class="text-2xl font-semibold text-center w-full">
                {"Home Page"}
            </span>
            {
                items  
                    .iter()
                    .map(|i| html! { <ImagePlaceholderSkeleton class="mt-2" /> })
                    .collect::<Vec<_>>()
            }
        </section>
    }
}
