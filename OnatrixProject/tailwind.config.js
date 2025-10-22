/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Views/**/*.cshtml",
    "./Views/Partials/**/*.cshtml",
    "./wwwroot/js/**/*.js"
  ],
  theme: {
    extend: {
      colors: {
        primary: "var(--color-primary)",
        secondary: "var(--color-secondary)",
        white: "var(--color-white)",
        "border-grey": "var(--color-grey)",
      },
    fontFamily: {
      poppins: ['Poppins', 'sans-serif'],
    }
    } 
    },
  plugins: []
}