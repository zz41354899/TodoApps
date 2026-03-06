/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Components/**/*.{razor,html,cshtml}",
    "./Pages/**/*.{razor,html,cshtml}",
    "./Shared/**/*.{razor,html,cshtml}",
    "./**/*.razor"
  ],
  theme: {
    extend: {},
  },
  plugins: [],
}
