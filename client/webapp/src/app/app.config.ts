import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import {
  API_BASE_URL,
  ExtraToppingClient,
  PizzaClient,
} from './api/core/services/service-proxies';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    PizzaClient,
    ExtraToppingClient,
    { provide: API_BASE_URL, useValue: 'http://localhost:5162' },
  ],
};
