cd front
npm install
ng test --no-watch --no-progress --browsers=ChromeHeadlessCI
ng e2e --protractor-config=e2e/protractor-ci.conf.js