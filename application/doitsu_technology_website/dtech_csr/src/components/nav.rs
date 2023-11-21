use yew::{function_component, html, Html};
use yew_router::Router;

#[function_component]
pub fn Nav() -> Html {
    html! {
    <nav class="mx-auto
        block 
        w-full
        bg-non_photo_blue 
        bg-opacity-80 
        py-2 
        px-4 
        text-black
        shadow-md
        backdrop-blur-2xl 
        backdrop-saturate-200 
        lg:px-8 
        lg:py-4">
        <div>
            <div class="container mx-auto flex items-center justify-between text-black">
                <a
                    href="#"
                    class="mr-4 block cursor-pointer py-1.5 text-base font-medium leading-relaxed text-inherit antialiased"
                >
                    <h1>{"D Tech"}</h1>
                </a>
            </div>
        </div>
    </nav>
    }
}

// <ul class="hidden items-center gap-6 lg:flex">
//     <li class="block p-1 font-sans text-sm font-normal leading-normal text-inherit antialiased">
//     <a class="flex items-center" href="#">
//         {"Home"}
//     </a>
//     </li>
// </ul>
// <button
//     class="middle none center hidden rounded-lg bg-gradient-to-tr from-pink-600 to-pink-400 py-2 px-4 font-sans text-xs font-bold uppercase text-white shadow-md shadow-pink-500/20 transition-all hover:shadow-lg hover:shadow-pink-500/40 active:opacity-[0.85] disabled:pointer-events-none disabled:opacity-50 disabled:shadow-none lg:inline-block"
//     type="button"
//     data-ripple-light="true"
// >
//     <span>{"Buy Now"}</span>
// </button>
// <button
//     class="middle none relative ml-auto h-6 max-h-[40px] w-6 max-w-[40px] rounded-lg text-center font-sans text-xs font-medium uppercase text-blue-gray-500 transition-all hover:bg-transparent focus:bg-transparent active:bg-transparent disabled:pointer-events-none disabled:opacity-50 disabled:shadow-none lg:hidden"
//     data-collapse-target="navbar"
// >
//     <span class="absolute top-1/2 left-1/2 -translate-y-1/2 -translate-x-1/2 transform">
//     <svg
//         xmlns="http://www.w3.org/2000/svg"
//         class="h-6 w-6"
//         fill="none"
//         stroke="currentColor"
//         strokeWidth="2"
//     >
//         <path
//         strokeLinecap="round"
//         strokeLinejoin="round"
//         d="M4 6h16M4 12h16M4 18h16"
//         ></path>
//     </svg>
//     </span>
// </button>
