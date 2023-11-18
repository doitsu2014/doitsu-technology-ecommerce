const withMT = require("@material-tailwind/html/utils/withMT");

module.exports = withMT({
    content: ["./src/**/*.rs", "./index.html", "*.html", "*.css"],
    theme: {},
    variants: {},
    plugins: [
    ]
});
