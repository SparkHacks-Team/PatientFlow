/** @type {import('tailwindcss').Config} */

export default {
  content: ['./src/**/*'],
  theme: {
    extend: {
      animation: {
        'fade': 'fade 3s ease-out 0.75s forwards',
      },
      keyframes: {
        fade: {
          '0%': {opacity: 0},
          '100%': { opacity: 1 },
        }
      }
    },
  },
  plugins: [require("daisyui")],
  // layers: [
  //   base = true,
  //   components = true,
  //   utilities = true,
  //
}

