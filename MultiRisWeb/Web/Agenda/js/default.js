function init() {
  cal.setCalendars(CalendarList);

  setRenderRangeText();
  setSchedules();
  setEventListener();
}

function getDataAction(target) {
  return target.dataset ? target.dataset.action : target.getAttribute('data-action');
}

function setDropdownCalendarType() {
  var calendarTypeName = document.getElementById('calendarTypeName');
  var calendarTypeIcon = document.getElementById('calendarTypeIcon');
  var options = cal.getOptions();
  var type = cal.getViewName();
  var iconClassName;

  if (type === 'day') {
    type = 'Daily';
    iconClassName = 'calendar-icon ic_view_day';
  } else if (type === 'week') {
    type = 'Weekly';
    iconClassName = 'calendar-icon ic_view_week';
  } else if (options.month.visibleWeeksCount === 2) {
    type = '2 weeks';
    iconClassName = 'calendar-icon ic_view_week';
  } else if (options.month.visibleWeeksCount === 3) {
    type = '3 weeks';
    iconClassName = 'calendar-icon ic_view_week';
  } else {
    type = 'Monthly';
    iconClassName = 'calendar-icon ic_view_month';
  }

  calendarTypeName.innerHTML = type;
  calendarTypeIcon.className = iconClassName;
}

function onClickMenu(e) {
  var target = $(e.target).closest('a[role="menuitem"]')[0];
  var action = getDataAction(target);
  var options = cal.getOptions();
  var viewName = '';

  switch (action) {
    case 'toggle-daily':
      viewName = 'day';
      break;
    case 'toggle-weekly':
      viewName = 'week';
      break;
    case 'toggle-monthly':
      options.month.visibleWeeksCount = 0;
      viewName = 'month';
      break;
    case 'toggle-weeks2':
      options.month.visibleWeeksCount = 2;
      viewName = 'month';
      break;
    case 'toggle-weeks3':
      options.month.visibleWeeksCount = 3;
      viewName = 'month';
      break;
    case 'toggle-narrow-weekend':
      options.month.narrowWeekend = !options.month.narrowWeekend;
      options.week.narrowWeekend = !options.week.narrowWeekend;
      viewName = cal.getViewName();

      target.querySelector('input').checked = options.month.narrowWeekend;
      break;
    case 'toggle-start-day-1':
      options.month.startDayOfWeek = options.month.startDayOfWeek ? 0 : 1;
      options.week.startDayOfWeek = options.week.startDayOfWeek ? 0 : 1;
      viewName = cal.getViewName();

      target.querySelector('input').checked = options.month.startDayOfWeek;
      break;
    case 'toggle-workweek':
      options.month.workweek = !options.month.workweek;
      options.week.workweek = !options.week.workweek;
      viewName = cal.getViewName();

      target.querySelector('input').checked = !options.month.workweek;
      break;
    default:
      break;
  }

  cal.setOptions(options, true);
  cal.changeView(viewName, true);

  setDropdownCalendarType();
  setRenderRangeText();
  setSchedules();
}

function onClickNavi(e) {
  var action = getDataAction(e.target);

  switch (action) {
    case 'move-prev':
      cal.prev();
      break;
    case 'move-next':
      cal.next();
      break;
    case 'move-today':
      cal.today();
      break;
    default:
      return;
  }

  setRenderRangeText();
  setSchedules();
}

function setRenderRangeText() {
  var renderRange = document.getElementById('renderRange');
  var options = cal.getOptions();
  var viewName = cal.getViewName();
  var html = [];
  if (viewName === 'day') {
    html.push(moment(cal.getDate().getTime()).format('YYYY.MM.DD'));
  } else if (viewName === 'month' &&
    (!options.month.visibleWeeksCount || options.month.visibleWeeksCount > 4)) {
    html.push(moment(cal.getDate().getTime()).format('YYYY.MM'));
  } else {
    html.push(moment(cal.getDateRangeStart().getTime()).format('YYYY.MM.DD'));
    html.push(' ~ ');
    html.push(moment(cal.getDateRangeEnd().getTime()).format(' MM.DD'));
  }
  renderRange.innerHTML = html.join('');
}

function setSchedules() {
  cal.clear();
  generateSchedule(cal.getViewName(), cal.getDateRangeStart(), cal.getDateRangeEnd());
//   cal.createSchedules([
//     {
//         id: '1',
//         calendarId: '1',
//         title: 'my schedule',
//         category: 'time',
//         dueDateClass: '',
//         start: '2018-01-18T22:30:00+09:00',
//         end: '2018-01-19T02:30:00+09:00'
//     },
//     {
//         id: '2',
//         calendarId: '1',
//         title: 'second schedule',
//         category: 'time',
//         dueDateClass: '',
//         start: '2018-01-18T17:30:00+09:00',
//         end: '2018-01-19T17:31:00+09:00'
//     }
// ]);
  // cal.createSchedules(ScheduleList);
  cal.createSchedules([
    {
        id: '1',
        calendarId: '1',
        title: '08:30 Andrea Rivera - Dr. Jorge Cubillos',
        category: 'time',
        dueDateClass: '',
        isAllday : true,
        start: '2020-05-22T08:30:00',
        end: '2020-05-22T09:30:00'
    },
    {
        id: '2',
        calendarId: '2',
        title: '09:00 Matías Jorquera - Dr. Catalina Melo',
        category: 'time',
        dueDateClass: '',
        start: '2020-05-22T09:30:00',
        end: '2020-05-22T10:30:00'
    },
    {
        id: '3',
        calendarId: '1',
        title: '10:00 Jorge Pereira - Dr. Ana Cabrera',
        category: 'time',
        dueDateClass: '',
        start: '2020-05-20T10:00:00',
        end: '2020-05-20T11:30:00'
    },
    {
        id: '4',
        calendarId: '2',
        title: '09:30 Elizabeth Parra - Dr. Jorge Cubillos',
        category: 'time',
        dueDateClass: '',
        start: '2020-05-22T09:30:00',
        end: '2020-05-22T10:30:00'
    },
    {
        id: '5',
        calendarId: '2',
        title: '09:30 Elizabeth Parra - Dr. Jorge Cubillos',
        category: 'time',
        dueDateClass: '',
        start: '2020-05-22T09:30:00',
        end: '2020-05-22T10:30:00'
    },
    {
        id: '6',
        calendarId: '1',
        title: '09:30 Elizabeth Parra - Dr. Jorge Cubillos',
        category: 'time',
        dueDateClass: '',
        start: '2020-06-22T09:30:00',
        end: '2020-06-22T10:30:00'
    },
    {
        id: '7',
        calendarId: '1',
        title: '11:00 Mario Canales - Dr. Jorge Cubillos',
        category: 'time',
        dueDateClass: '',
        start: '2020-06-22T11:00:00',
        end: '2020-06-22T11:30:00'
    },
    {
        id: '8',
        calendarId: '2',
        title: '12:30 Belén Pizarro - Dr. Ramiro Pérez',
        category: 'time',
        dueDateClass: '',
        start: '2020-06-24T12:30:00',
        end: '2020-06-24T13:00:00'
    },
    {
        id: '9',
        calendarId: '1',
        title: '15:15 Esteban Rojas Araya - Dr. Jorge Cubillos',
        category: 'time',
        dueDateClass: '',
        start: '2020-06-22T15:15:00',
        end: '2020-06-22T16:00:00'
    },
    {
        id: '10',
        calendarId: '2',
        title: '08:00 Katherine Acuña - Dr. Ramiro Pérez',
        category: 'time',
        dueDateClass: '',
        start: '2020-06-17T08:00:00',
        end: '2020-06-17T09:00:00'
    },
    {
        id: '11',
        calendarId: '2',
        title: '12:30 Erick Canales Urrutia - Dr. Ramiro Pérez',
        category: 'time',
        dueDateClass: '',
        start: '2020-06-17T16:30:00',
        end: '2020-06-17T17:00:00'
    }
    ,
    {
        id: '12',
        calendarId: '2',
        title: 'RX 19:30 - 20:00 Erick Canales Urrutia',
        category: 'time',
        dueDateClass: '',
        start: '2020-07-03T19:30:00',
        end: '2020-07-03T20:00:00'
    },
    {
        id: '13',
        calendarId: '2',
        title: 'MG 20:00 - 20:30 Juan Perez',
        category: 'time',
        dueDateClass: '',
        start: '2020-07-03T20:00:00',
        end: '2020-07-03T20:30:00'
    }
]);

  refreshScheduleVisibility();
}


function refreshScheduleVisibility() {
  var calendarElements = Array.prototype.slice.call(document.querySelectorAll('#calendarList input'));

  CalendarList.forEach(function(calendar) {
    cal.toggleSchedules(calendar.id, !calendar.checked, false);
  });

  cal.render(true);

  calendarElements.forEach(function(input) {
    var span = input.nextElementSibling;
    span.style.backgroundColor = input.checked ? span.style.borderColor : 'transparent';
  });
}

resizeThrottled = tui.util.throttle(function() {
  cal.render();
}, 50);

function setEventListener() {
  $('.select-temporalidad').on('click', onClickMenu);

   $('#menu-navi').on('click', onClickNavi);
  window.addEventListener('resize', resizeThrottled);
}

cal.on({
  'clickTimezonesCollapseBtn': function(timezonesCollapsed) {
    if (timezonesCollapsed) {
      cal.setTheme({
        'week.daygridLeft.width': '77px',
        'week.timegridLeft.width': '77px'
      });
    } else {
      cal.setTheme({
        'week.daygridLeft.width': '60px',
        'week.timegridLeft.width': '60px'
      });
    }

    return true;
  }
});

init();
