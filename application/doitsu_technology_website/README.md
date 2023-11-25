# Introduce

## 1. Install and Setup

-   Of course the rust tool! (Skip this one if you have installed it on your machine): `curl --proto '=https' --tlsv1.2 -sSf https://sh.rustup.rs | sh`. And append to the PATH the bin `export PATH=$PATH:$HOME/.cargo/bin`
-   The first tool need to setup in there project is `bonnie`, you can install it using `cargo install bonnie`
-   The second tool need to setup in there project is `npm`.
-   Tailwindcss and vscode, you need to config the including languages to load tailwindcss intellisense in \*.rs files. There is the config:

```json
    "tailwindCSS.includeLanguages": {
        "rust": "html"
    }
```
After you have installed all neccessary tools.
Please add targeting webassembly platform to your rustc: `rustup target add wasm32-unknown-unknown`

## 2. Run

Please use bonnie to run build csr first: `bonnie build csr`
Then your application is ready to run working.

## 3. Dependencies

This application is using the Flowbite to enhance the UI. So, please refer this link to get more detail: https://flowbite.com/docs/components/navbar/#solid-background
- Flowbite Version: `2.2.0`
- Tailwindcss Version: `3.3.5`


