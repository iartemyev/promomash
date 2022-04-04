import { Injectable } from '@angular/core';
import { LoggerService } from '../service/logger.service';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { IRootState, SignUpAction, SignUpSelector } from '../../store';

@Injectable({
	providedIn: 'root',
})
export class StoreFacade {
	public constructor(private _store$: Store<IRootState>, private _logger: LoggerService) {}

	public selectCountryListLoading(): Observable<boolean> {
		return this._store$.select(SignUpSelector.countryListLoading);
	}

	public provinceListLoading(payload: string) {
		this._store$.dispatch(SignUpAction.ProvinceListLoading({ payload }));
	}
}
