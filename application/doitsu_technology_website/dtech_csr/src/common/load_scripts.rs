use web_sys::Element;

pub fn initialize_scripts() {
    // load_script_by_src(
    //     "https://cdnjs.cloudflare.com/ajax/libs/flowbite/2.2.0/datepicker.min.js".to_string()
    // );

    // load_script_by_src(
    //     "https://unpkg.com/@material-tailwind/html@latest/scripts/ripple.js".to_string()
    // );
    // load_script_by_src(
    //     "collapse.js".to_string()
    // );
    // load_script_by_src(
    //     "ripple.js".to_string()
    // );
}

pub fn load_script_by_src(src: String) -> Element {
    let window = web_sys::window().expect("no global `window` exists");
    let document = window.document().expect("should have a document on window");
    let script = document.create_element("script").expect("could not create script element");
    script.set_attribute("src", src.as_str()).expect("could not set `src` attribute");
    // script.set_attribute("async", "true").expect("could not set `async` attribute");
    // script.set_attribute("type", "javascript").expect("could not set `type` attribute");
    document
        .head()
        .expect("document should have a head")
        .append_child(&script)
        .expect("couldn't append script to head");
    return script;
}
