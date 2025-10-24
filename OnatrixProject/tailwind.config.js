/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./Views/**/*.cshtml",
    "./Views/Partials/**/*.cshtml",
    "./wwwroot/js/**/*.js",
    "./App_Plugins/OnatrixRte/**/*.json" 
  ],
  safelist: [ 
    'text-primary',
    'text-secondary',
    'text-body-text',
    'text-body-100',
    'text-rte-xl',
    'text-rte-lg',
    'text-rte-md',
    'text-rte-sm',
    'text-rte-xs',
    'font-light',
    'font-normal',
    'font-bold',
    'rte-ul'
  ],
  theme: {
    extend: {
      colors: {
        primary: "var(--color-primary)",
        secondary: "var(--color-secondary)",
        white: "var(--color-white)",
        black: "var(--color-black)",
        "white-100": "var(--color-white-100)",
        "body-text": "var(--color-body-text)",
        "border-gray": "var(--color-border-gray)"
      },
      fontFamily: {
        poppins: ['Poppins', 'sans-serif']
      },
      fontSize: {
        'rte-xl': 'var(--text-rte-xl)',
        'rte-lg': 'var(--text-rte-lg)',
        'rte-md': 'var(--text-rte-md)',
        'rte-sm': 'var(--text-rte-sm)',
        'rte-xs': 'var(--text-rte-xs)'
      }
    }
  },
  plugins: []
};