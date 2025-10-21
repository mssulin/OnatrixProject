/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "../Views/**/*.cshtml",
    "../**/*.cshtml",
    "./**/*.{html,js}"
  ],
  theme: {
    extend: {
      fontFamily: { poppins: ['Poppins','sans-serif'] },
    },
  },
  plugins: [],
}