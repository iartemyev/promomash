import { Injectable } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { LoggerService } from '../service/logger.service';
import { LogHelper } from '../helper/log.helper';
import { Location } from '@angular/common';

export interface IRouterPayload {
	path: string[];
	queryParams?: object;
	extras?: NavigationExtras;
}

@Injectable({
	providedIn: 'root',
})
export class RouterFacade {
	public constructor(
		private _location: Location,
		private _router: Router,
		private _logger: LoggerService,
	) {}

	private navigate(payload: IRouterPayload) {
		this._logger.debug(`[NAVIGATE] to: ${LogHelper.pretty(payload)}`);
		let { path, queryParams, extras } = payload;
		this._router
			.navigate(path, {
				queryParams,
				...extras,
			})
			.then();
	}

	public forward() {
		this._logger.debug(`[NAVIGATE] to forward`);
		this._location.forward();
	}

	public backward() {
		this._logger.debug(`[NAVIGATE] to backward`);
		this._location.back();
	}

	public home() {
		let payload: IRouterPayload = {
			path: [
				//`${this._customer}/${this._settings.touch ? CUSTOMER_PRODUCT_ITEM : CUSTOMER_PRODUCT_MENU}`,
			],
		};
		this.navigate(payload);
	}
}
