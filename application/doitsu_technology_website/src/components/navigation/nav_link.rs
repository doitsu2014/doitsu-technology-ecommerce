
use yew::prelude::*;
use yew::{classes, function_component, html, Html};
use yew_router::prelude::*;

use crate::Route;

#[derive(Properties, PartialEq)]
pub struct NavLinkProps {
    pub route: Route,
}

#[function_component]
pub fn NavLink(props: &NavLinkProps) -> Html {
    let location = use_location().expect("Failed to get location");
    let location_path = location.path();
    let owned_route = props.route.to_owned();
    let route_display_name = match owned_route {
        Route::Home => "Home",
        Route::NotFound => "Not Found",
        Route::Posts => "Posts",
        Route::Post { id: _ } => "Post"
    };
    let route_path = owned_route.to_path();
    let is_active = location_path == route_path;

    // props
    let base_classes = vec!["block", "py-2", "px-3"];
    let active_classes = vec![
        "bg-blue-700",
        "rounded",
        "md:bg-transparent",
        "md:text-blue-700",
        "md:p-0",
        "md:dark:text-blue-500",
    ];
    let inactive_classes = vec![
        "text-gray-900",
        "rounded",
        "hover:bg-gray-100",
        "md:hover:bg-transparent",
        "md:hover:text-blue-700",
        "md:p-0",
        "md:dark:hover:text-blue-500",
        "dark:text-white",
        "dark:hover:bg-gray-700",
        "dark:hover:text-white",
        "md:dark:hover:bg-transparent",
        "dark:border-gray-700",
    ];

    html! {
        <Link<Route>
            classes={classes!(
                base_classes,
                if is_active { active_classes } else { inactive_classes }
            )}
            to={owned_route}
        >
            { route_display_name }
        </Link<Route>>
    }
}
