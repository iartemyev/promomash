import { Injectable } from '@angular/core';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class StripUndefinedParamsInterceptor implements HttpInterceptor {
	public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		let params = request.params;
		for (const key of request.params.keys()) {
			if (params.get(key) === undefined) {
				params = params.delete(key, undefined);
			}

			if (params.get(key) === null) {
				params = params.delete(key, null!);
			}
		}

		let clone = request.clone({ params });
		return next.handle(clone);
	}
}
