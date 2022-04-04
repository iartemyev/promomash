import { Injectable } from '@angular/core';
import {
	HttpErrorResponse,
	HttpEvent,
	HttpHandler,
	HttpInterceptor,
	HttpRequest,
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { LoggerService } from '../service/logger.service';
import { RouterFacade } from '../facade/router.facade';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
	public constructor(private router: RouterFacade, private _logger: LoggerService) {}

	public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return next.handle(req).pipe(
			catchError((response) => {
				if (response instanceof HttpErrorResponse && response.status === 401) {
					this._logger.warn(req);
				}

				if (response instanceof HttpErrorResponse && !response.ok && response.status >= 502) {
					this._logger.warn(`Offline with ${response.url}`);
					this.router.errorPage();
				}

				return throwError(response);
			}),
		);
	}
}
