'use strict';

/*eslint-disable*/

var ScheduleList = [];

var SCHEDULE_CATEGORY = [
    'milestone',
    'task'
];

function ScheduleInfo() {
    this.id = null;
    this.calendarId = null;

    this.title = null;
    this.body = null;
    this.isAllday = false;
    this.start = null;
    this.end = null;
    this.category = '';
    this.dueDateClass = '';

    this.color = null;
    this.bgColor = null;
    this.dragBgColor = null;
    this.borderColor = null;
    this.customStyle = '';

    this.isFocused = false;
    this.isPending = false;
    this.isVisible = true;
    this.isReadOnly = false;
    this.goingDuration = 0;
    this.comingDuration = 0;
    this.recurrenceRule = '';
    this.state = '';

    this.raw = {
        memo: '',
        hasToOrCc: false,
        hasRecurrenceRule: false,
        location: null,
        class: 'public', // or 'private'
        creator: {
            name: '',
            avatar: '',
            company: '',
            email: '',
            phone: ''
        }
    };
}

function generateTime(schedule, renderStart, renderEnd) {

    console.log("renderStart: ",renderStart);
    console.log("renderEnd: ",renderEnd);
    // var st = '2020-05-22T10:30:00+03:00';
    // var end = '2020-05-22T11:30:00+03:00';
    //  var startDate = moment(st.getTime());
    //  var endDate = moment(end.getTime());
    // var diffDate = endDate.diff(startDate, 'days');

    // console.log("startDate: ",startDate);
    // console.log("endDate: ",endDate);

    // schedule.isAllday = chance.bool({likelihood: 30});
    // if (schedule.isAllday) {
    //     schedule.category = 'allday';
    // } else if (chance.bool({likelihood: 30})) {
    //     schedule.category = SCHEDULE_CATEGORY[chance.integer({min: 0, max: 1})];
    //     if (schedule.category === SCHEDULE_CATEGORY[1]) {
    //         schedule.dueDateClass = 'morning';
    //     }
    // } else {
    //     schedule.category = 'time';
    // }

    // startDate.add(chance.integer({min: 0, max: diffDate}), 'days');
    // startDate.hours(chance.integer({min: 0, max: 23}))
    // startDate.minutes(chance.bool() ? 0 : 30);
    // schedule.start = startDate;

    // endDate = moment(startDate);
    // if (schedule.isAllday) {
    //     endDate.add(chance.integer({min: 0, max: 3}), 'days');
    // }

    // schedule.end = endDate
    //     .add(chance.integer({min: 1, max: 4}), 'hour')
    //     .toDate();

    // if (!schedule.isAllday && chance.bool({likelihood: 20})) {
    //     schedule.goingDuration = chance.integer({min: 30, max: 120});
    //     schedule.comingDuration = chance.integer({min: 30, max: 120});;

    //     if (chance.bool({likelihood: 50})) {
    //         schedule.end = schedule.start;
    //     }
    // }
}

function generateNames() {
    var names = [];
    var i = 0;
    var length = chance.integer({min: 1, max: 10});

    for (; i < length; i += 1) {
        names.push(chance.name());
    }

    return names;
}

function generateRandomSchedule(calendar, renderStart, renderEnd) {
    var schedule = new ScheduleInfo();

    schedule.id = chance.guid();
    schedule.calendarId = calendar.id;

    schedule.title = chance.sentence({words: 3});
    schedule.body = chance.bool({likelihood: 20}) ? chance.sentence({words: 10}) : '';
    schedule.isReadOnly = chance.bool({likelihood: 20});
    generateTime(schedule, renderStart, renderEnd);

    schedule.isPrivate = chance.bool({likelihood: 10});
    schedule.location = chance.address();
    schedule.attendees = chance.bool({likelihood: 70}) ? generateNames() : [];
    schedule.recurrenceRule = chance.bool({likelihood: 20}) ? 'repeated events' : '';
    schedule.state = chance.bool({likelihood: 20}) ? 'Free' : 'Busy';
    schedule.color = calendar.color;
    schedule.bgColor = calendar.bgColor;
    schedule.dragBgColor = calendar.dragBgColor;
    schedule.borderColor = calendar.borderColor;

    if (schedule.category === 'milestone') {
        schedule.color = schedule.bgColor;
        schedule.bgColor = 'transparent';
        schedule.dragBgColor = 'transparent';
        schedule.borderColor = 'transparent';
    }

    schedule.raw.memo = chance.sentence();
    schedule.raw.creator.name = chance.name();
    schedule.raw.creator.avatar = chance.avatar();
    schedule.raw.creator.company = chance.company();
    schedule.raw.creator.email = chance.email();
    schedule.raw.creator.phone = chance.phone();

    if (chance.bool({ likelihood: 20 })) {
        var travelTime = chance.minute();
        schedule.goingDuration = travelTime;
        schedule.comingDuration = travelTime;
    }

    ScheduleList.push(schedule);
}

function crearAgendamiento(calendar, renderStart, renderEnd) {
    var schedule = new ScheduleInfo();

    // schedule.id = "42678";
    schedule.calendarId = calendar.id;

    schedule.title = "Jordan Meneses";
    //schedule.body = chance.bool({likelihood: 20}) ? chance.sentence({words: 10}) : '';
    // schedule.isReadOnly = true;
    generateTime(schedule, renderStart, renderEnd);
   // var h = new Date().getHours();
    // schedule.start = '2020-05-22T10:30:00+03:00';
    // schedule.end = '2020-05-22T11:30:00+03:00';

    // schedule.isPrivate = false;
    // schedule.location = "Hospital Militar";
    // schedule.attendees = null;
    // schedule.recurrenceRule = false;
    // schedule.state = 'Busy';
    // schedule.color = calendar.color;
    // schedule.bgColor = calendar.bgColor;
    // schedule.dragBgColor = calendar.dragBgColor;
    // schedule.borderColor = calendar.borderColor;

    // if (schedule.category === 'milestone') {
    //     schedule.color = schedule.bgColor;
    //     schedule.bgColor = 'transparent';
    //     schedule.dragBgColor = 'transparent';
    //     schedule.borderColor = 'transparent';
    // }

    // schedule.raw.memo = "xxxxxxx";
    // schedule.raw.creator.name = "IRAD";
    // schedule.raw.creator.avatar = chance.avatar();
    // schedule.raw.creator.company = chance.company();
    // schedule.raw.creator.email = chance.email();
    // schedule.raw.creator.phone = chance.phone();

    // if (chance.bool({ likelihood: 20 })) {
    //     var travelTime = chance.minute();
    //     schedule.goingDuration = travelTime;
    //     schedule.comingDuration = travelTime;
    // }

    //console.log("schedule: ",schedule);

    ScheduleList.push(schedule);
}

function generateSchedule(viewName, renderStart, renderEnd) {
    ScheduleList = [];
    crearAgendamiento(calendar, renderStart, renderEnd);
    // CalendarList.forEach(function(calendar) {
    //     var i = 0, length = 10;
    //     if (viewName === 'month') {
    //         length = 3;
    //     } else if (viewName === 'day') {
    //         length = 4;
    //     }
        
    //     crearAgendamiento(calendar, renderStart, renderEnd);
    //     // for (; i < length; i += 1) {
    //     //     generateRandomSchedule(calendar, renderStart, renderEnd);
    //     // }
    // });
}
