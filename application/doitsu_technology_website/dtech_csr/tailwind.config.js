module.exports = {
    content: ["./src/**/*.rs", "./index.html", "*.html", "*.css"],
    theme: {},
    variants: {},
    plugins: [
        require("@tailwindcss/typography"),
        require("@tailwindcss/forms"),
        require("@tailwindcss/aspect-ratio"),
        require("@tailwindcss/container-queries"),
    ]
};
