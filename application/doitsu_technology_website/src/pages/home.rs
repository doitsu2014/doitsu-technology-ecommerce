use wasm_bindgen::{JsCast, JsValue};
use web_sys::js_sys::{Array, Reflect};
use yew::{function_component, html, use_effect, Html};


use crate::components::skeletons::image_placeholder_skeleton::ImagePlaceholderSkeleton;

#[function_component]
pub fn PageHome() -> Html {
    let items = (1..=80).collect::<Vec<_>>();
    use_effect(|| {
        let window = web_sys::window().expect("window does not exist");
        let flowbite = window.get("Flowbite").expect("Flowbite.initDatepickers");
        let init_date_pickers =
            Reflect::get(&flowbite, &JsValue::from_str("initDatepickers")).unwrap();
        let arr = Array::new();
        // let function_1 = function.("initDatepickers").expect("Flowbite.initDatepickers");
        // web_sys::console::log_1(&initDatepickers);
        Reflect::apply(
            init_date_pickers.unchecked_ref(),
            &JsValue::from_str(""),
            &arr,
        )
        .expect("No error");
    });

    html! {
      <section class="flex flex-col w-2/3 mx-auto text-center text-xl mt-4">
        <div class="flex flex-row-reverse w-full">
          <div class="relative max-w-sm">
            <div class="absolute inset-y-0 start-0 flex items-center ps-3.5 pointer-events-none">
              <svg class="w-4 h-4 text-gray-500 dark:text-gray-400" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
                <path d="M20 4a2 2 0 0 0-2-2h-2V1a1 1 0 0 0-2 0v1h-3V1a1 1 0 0 0-2 0v1H6V1a1 1 0 0 0-2 0v1H2a2 2 0 0 0-2 2v2h20V4ZM0 18a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V8H0v10Zm5-8h10a1 1 0 0 1 0 2H5a1 1 0 0 1 0-2Z"/>
              </svg>
            </div>
            <input datepicker={{""}} type="text" class="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full ps-10 p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="Select date" />
          </div>
        </div>
        <span class="text-2xl font-semibold text-center w-full">
            {"Home Page 1 2"}
        </span>
        {
            items
                .iter()
                .map(|_| html! { <ImagePlaceholderSkeleton class="mt-2" /> })
                .collect::<Vec<_>>()
        }
      </section>
    }
}
