import { Injectable } from '@angular/core';
import { StoreFacade } from '../../shared/facade/store.facade';
import { RouterFacade } from '../../shared/facade/router.facade';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { AuthService } from '../../shared/service/rest-api/auth.service';
import { CountryService } from '../../shared/service/rest-api/country.service';
import { ProvinceService } from '../../shared/service/rest-api/province.service';
import { SignUpAction } from './index';
import { catchError, map, of, switchMap } from 'rxjs';

@Injectable()
export class SignUpEffect {
	public constructor(
		private _authService: AuthService,
		private _countryService: CountryService,
		private _provinceService: ProvinceService,
		private _actions$: Actions,
		private _store: StoreFacade,
		private _router: RouterFacade,
	) {}

	public countryListLoading$ = createEffect(() =>
		this._actions$.pipe(
			ofType(SignUpAction.CountryListLoading),
			switchMap(() => {
				return this._countryService.list().pipe(
					map((response) => {
						return SignUpAction.CountryListSuccess({ payload: response });
					}),
					catchError((error: Error) => {
						return of(SignUpAction.CountryListFailure({ payload: error }));
					}),
				);
			}),
		),
	);

	public provinceListLoading$ = createEffect(() =>
		this._actions$.pipe(
			ofType(SignUpAction.ProvinceListLoading),
			map((action) => action.payload),
			switchMap((payload) => {
				return this._provinceService.list(payload).pipe(
					map((response) => {
						return SignUpAction.ProvinceListSuccess({ payload: response });
					}),
					catchError((error: Error) => {
						return of(SignUpAction.ProvinceListFailure({ payload: error }));
					}),
				);
			}),
		),
	);

	public signUpLoading$ = createEffect(() =>
		this._actions$.pipe(
			ofType(SignUpAction.SignUpLoading),
			map((action) => action.payload),
			switchMap((payload) => {
				return this._authService.signUp(payload).pipe(
					map((response) => {
						return SignUpAction.SignUpSuccess({ payload: response });
					}),
					catchError((error: Error) => {
						return of(SignUpAction.SignUpFailure({ payload: error }));
					}),
				);
			}),
		),
	);
}
