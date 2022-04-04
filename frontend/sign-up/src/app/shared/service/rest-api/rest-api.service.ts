import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, share } from 'rxjs';
import { AppSettingsService } from '../app-settings.service';
import { LoggerService } from '../logger.service';
import { LogHelper } from '../../helper/log.helper';

@Injectable()
export class RestApiService {
	private readonly _apiUrl: string = ``;

	public constructor(
		private _http: HttpClient,
		private _settingsService: AppSettingsService,
		private _logger: LoggerService,
	) {
		this._apiUrl = `http://${_settingsService.settings.apiUrl}/api`;
		_logger.debug(`RestApiService _apiUrl=${this._apiUrl}`);
	}

	public Get<T>(path: string, params?: any): Observable<T> {
		this._logger.debug(`[REST-API][GET] ${path} params=${LogHelper.pretty(params)}`);

		return this._http
			.get<T>(`${this._apiUrl}/${path}`, {
				params,
			})
			.pipe(share());
	}

	public GetText(path: string, params?: any): Observable<string> {
		this._logger.debug(`[REST-API][GET-TEXT] ${path} params=${LogHelper.pretty(params)}`);

		return this._http
			.get<string>(`${this._apiUrl}/${path}`, {
				responseType: 'text' as 'json',
				params,
			})
			.pipe(share());
	}

	public GetBlob(path: string, params?: any): Observable<Blob> {
		this._logger.debug(`[REST-API][GET-BLOB] ${path} params=${LogHelper.pretty(params)}`);

		return this._http
			.get(`${this._apiUrl}/${path}`, {
				responseType: 'blob',
				params,
			})
			.pipe(share());
	}

	public Post<T>(path: string, body?: any, params?: any, headers?: HttpHeaders): Observable<T> {
		this._logger.debug(
			`[REST-API][POST] ${path} body ${LogHelper.pretty(body)} params=${LogHelper.pretty(
				params,
			)} headers=${LogHelper.pretty(headers)}`,
		);

		return this._http
			.post<T>(`${this._apiUrl}/${path}`, body, {
				params,
				headers,
			})
			.pipe(share());
	}

	public Put<T>(path: string, body: any, params?: any, headers?: HttpHeaders) {
		this._logger.debug(
			`[REST-API][PUT] ${path} body=${LogHelper.pretty(body)} params=${LogHelper.pretty(
				params,
			)} headers=${LogHelper.pretty(headers)}`,
		);

		return this._http
			.put<T>(`${this._apiUrl}/${path}`, body, {
				headers,
				params,
			})
			.pipe(share());
	}

	public Delete(path: string, body: any, params?: any) {
		this._logger.debug(
			`[REST-API][DELETE] ${path} body=${LogHelper.pretty(body)} params=${LogHelper.pretty(
				params,
			)}`,
		);

		return this._http
			.request<void>('delete', `${this._apiUrl}/${path}`, {
				params,
				body,
			})
			.pipe(share());
	}
}
