// Programming Languages and Frameworks

let tools = [
    "HTML",
    "JavaScript",
    "CSS",
    "C#",
    "Java",
    "Python",
    "Spring Boot",
    ".NET",
    "PHP",
    "Google Fu",
    "Git",
    "Github"
]
// console.log("The root Array:", tools)
// for(let i = 0; i < tools.length; i++){
//     console.log("looping through array:", tools[i])
//     // return tools[i]
// }
function siteTools(arr) {
    var node = document.createElement('div') // creating a html div and giving it the variable node 
    node.setAttribute('class', 'node')
    // var img = document.createElement('img')
    // img.src = 
    for(let i = 0; i  < arr.length; i++) {
        console.log(arr[i])
        var toolDiv = document.createElement('div')
        var h3 = document.createElement('h3')
        var tool = document.createTextNode(arr[i])
        h3.appendChild(tool)
        // h3.setAttribute('class', )
        toolDiv.setAttribute('class', "toolDiv btn btn-outline-info")
        toolDiv.appendChild(h3)
        node.appendChild(toolDiv)
    }
    document.getElementById('tools').appendChild(node)
}





// Clock

function getSecondsSinceStartOfDay() {
    // below returning new date / seconds + min + hours
    // return example 43590
    let hour = new Date().getHours()
    let min = new Date().getMinutes()
    let sec = new Date().getSeconds()
    // console.log('hour', hour, 'min', min, 'sec', sec)
    let time = {hour: hour, min: min, sec: sec}

    // return time;
    return new Date().getSeconds() + 
      new Date().getMinutes() * 60 + 
      new Date().getHours() * 3600;
}

setInterval( function() {
    // getting time
    var time = getSecondsSinceStartOfDay();
    // printing time
    // console.log(time);
    // console.log("hour in setInterval",time.hour)
    // let hour = time.hour
    // let hourHand  = document.getElementById('hour')
    // let h = time.hour
    // h = 180
    // h *= 30
    // console.log(h)
    // let hourRotation = (target, val) => {
    //     target.style.transform = `rotate(${val}deg)`
    // } 
    // hourRotation()
    // let time[hour] *= 30; // 12 * 30 = 360deg
    // let time[min] *= 6;
    // let time[sec] *= 6; // 60 * 6 = 360deg
    // let hour = time/3600
    // console.log('hour',hour)
    // hour = parseInt(hour)
    // console.log('hour int',hour)
    // let min = (time/60)
    // console.log('min',min)
    // document.getElementById('hour').style.transform = `rotate(${h}deg)`
    // hour
    let hours = parseInt(time/3600)     // getting time from function dividing by 3600 (undo return)    
    var h_angle = (180 + hours*30)%360 //setting up the angle rotation (180 offsets the current angle (set to be at the 12 oclock position) plus the hours times 30 (the degrees to move each hour) modulus 360 so never goes outside of 360 degrees)
    document.getElementById('hour').style.transform = `rotate(${h_angle}deg)` // pushing to html

    // minutes
    let minutes = parseInt((time - hours*3600)/60)
    var m_angle = (180 + minutes*6)%360
    document.getElementById('minutes').style.transform = `rotate(${m_angle}deg)`

    // seconds
    let seconds = parseInt((time-minutes*60-hours*3600))
    var s_angle = (180 + seconds*6)%360
    document.getElementById('seconds').style.transform = `rotate(${s_angle}deg)`


}, 1000);
// above is how often to run function

// hour hand moves 30 degrees / hour
// min hand moves 6degrees / min
// second moves 1/10 degree / second

function est() {
    est = new Date(new Date().getTime() + -4*60*60*1000).toUTCString('en-GB')
    var local = new Date()
    local = `${local}`
    console.log('local', local)
    console.log('EST: ', est)
    // var adjust = est.slice(-12 )
    var adjust = est.substr(17,9)
    var cut = local.substr(16, 9)
    var hour = cut.substr(0, 2)
    console.log('just hour', hour)
    // cut.shift()
    // cut.shift()
    console.log('new cut', cut)
    console.log('adjust', adjust)
    // var cut = adjust.substr(0,9)
    // // var cut = adjust.slice(-9)÷
    console.log('cut', cut, typeof(cut))
    var zone = 'EST'
    // var final = cut + zone
    var final = adjust + zone
    var zone01 = 'EST'
    var zone02 = 'CST'
    console.log('final', final)
    var newEST = cut + zone01
    // var newCST = (cst) + zone02
    // console.log(newEST, newCST)
    // document.getElementById('neg4gmt').innerHTML = final
}
est()



const d = new Date()
console.log('d', d)

// convert to msec since Jan 1 1970  prints the miliseconds for the local time that is d
const localTime = d.getTime()
console.log('local time', localTime)

// obtain local UTC offset and convert to msec  // Gets the difference in minutes between the time on the local computer and Universal Coordinated Time (UTC).
const localOffset = d.getTimezoneOffset() * 60 * 1000
console.log('localOffset', localOffset)

// obtain UTC time in msec // adds above 2 together giving us UTC time so we can hard code adjust for other time zones
const utcTime = localTime + localOffset
console.log('utcTime', utcTime)






// Get time zone offset for NY, USA
const getEstOffset = () => {
    const stdTimezoneOffset = () => {
        var jan = new Date(0, 1)
        var jul = new Date(6, 1)
        console.log('stdTime', Math.max(jan.getTimezoneOffset(), jul.getTimezoneOffset()))
        // grabbing the time diff between jan and jul returning larger of 2 (if daylight savings these will have 2 numbers)
        return Math.max(jan.getTimezoneOffset(), jul.getTimezoneOffset())
    }

    var today = new Date()
    
    const isDstObserved = (today = Date) => {
        console.log(today.getTimezoneOffset() < stdTimezoneOffset())
        // is computer offset smaller than standard offset == returns true/false
        return today.getTimezoneOffset() < stdTimezoneOffset()
    }

    if (isDstObserved(today)) {
        console.log(-4)
        // returning the number of hours to ofset from utc if daylight observerd
        return -4
    } else {
        console.log(-5)
        // returning the number of hours to offset from utc if not observed (or current)
        return -5
    }
}
// getEstOffset()

// Get time zone offset for NY, USA
const getCstOffset = () => {
    const stdTimezoneOffset = () => {
        var jan = new Date(0, 1)
        var jul = new Date(6, 1)
        console.log('stdTime', Math.max(jan.getTimezoneOffset(), jul.getTimezoneOffset()))
        // grabbing the time diff between jan and jul returning larger of 2 (if daylight savings these will have 2 numbers)
        return Math.max(jan.getTimezoneOffset(), jul.getTimezoneOffset())
    }

    var today = new Date()
    
    const isDstObserved = (today = Date) => {
        console.log(today.getTimezoneOffset() < stdTimezoneOffset())
        // is computer offset smaller than standard offset == returns true/false
        return today.getTimezoneOffset() < stdTimezoneOffset()
    }

    if (isDstObserved(today)) {
        console.log(-5)
        // returning the number of hours to ofset from utc if daylight observerd
        return -5
    } else {
        console.log(-6)
        // returning the number of hours to offset from utc if not observed (or current)
        return -6
    }
}
// getCstOffset()

// obtain and add destination's UTC time offset
const estOffset = getEstOffset()
const estUsa = utcTime + (60 * 60 * 1000 * estOffset)
console.log('usa', estUsa)
// adjusts the time in milliseconds

const cstOffset = getCstOffset()
const cstUsa = utcTime + (60 * 60 * 1000 * cstOffset)
console.log('usa', cstUsa)


// convert msec value to date string
var newEST = new Date(estUsa)
console.log('newEST', newEST)
// changes back to normal time view
newEST = `${newEST}`
console.log('newEST', newEST, typeof(newEST))
newEST.substr(0,2)
console.log('newEST', newEST)
document.getElementById('est').innerHTML = newEST

const newCST = new Date(cstUsa)
console.log('newCST', newCST)
document.getElementById('cst').innerHTML = newCST