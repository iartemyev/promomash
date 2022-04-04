import { getSelectors, RouterReducerState } from '@ngrx/router-store';
import { createFeatureSelector, createSelector } from '@ngrx/store';

const routerState = createFeatureSelector<RouterReducerState>('router');

export const {
	selectCurrentRoute,
	selectFragment,
	selectQueryParams,
	selectQueryParam,
	selectRouteParam,
	selectRouteParams,
	selectUrl,
	selectRouteData,
} = getSelectors(routerState);

export const signUpFlagParam = createSelector(
	selectQueryParams,
	(params) => params && params['signup-flag'],
);
