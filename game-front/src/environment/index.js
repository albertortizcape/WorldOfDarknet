export const VUE_APP_HOST = (process.env.NODE_ENV === 'development') ? process.env.baseUrlDev : process.env.baseUrlPro
export const VUE_APP_HUB = (process.env.NODE_ENV === 'development') ? process.env.hubGameDev : process.env.hubGamePro

console.log('tocotó desde el environment!!!!')

if (process.env.NODE_ENV === 'development') {
  console.log('es dev')
  console.log(process.env.baseUrlDev)
} else {
  console.log('es PRO')
  console.log(process.env.baseUrlPro)
}

